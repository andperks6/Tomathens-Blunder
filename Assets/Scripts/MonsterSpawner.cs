using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {
    [System.Serializable]
    public class SpawnGroup
    {
        public string groupName = "New Group";
        public Transform centerPoint;         // Center of the spawn area
        public bool isEnabled = true;
        public float radius = 10f;           // Radius around center to spawn
        public int spawnCount = 3;           // How many spawn points to generate
        public bool useAdditionalMonstersOnly = false;
        [Range(0, 100)]
        public int additionalMonsterChance = 20;
        
        public float triggerDistance = 25f;     // Distance at which spawning triggers

    }

    [System.Serializable]
    private class SpawnPoint {
        public Vector3 position;
        public bool hasSpawned = false;
        public float lastSpawnTime = 0f;
    }

    // Monster references
    public GameObject cricketmage;
    public GameObject cricketwarrior;
    public GameObject beetlewarrior;

    private GameObject[] defaultMonsters;
    public GameObject[] additionalMonsters;  // Add more monsters through inspector
    private GameObject[] monsterPrefabs;     // Combined array of all monsters
    
    public SpawnGroup[] spawnGroups;        // Groups of spawn points
    public bool enableRespawn = true;       // Whether monsters should respawn after being defeated
    public float respawnTime = 30f;         // Time before respawning is allowed
    public float minSpawnDelay = 5f;        // Minimum time between spawns
    
    private Transform player;               // Reference to the player
    private Dictionary<SpawnGroup, List<SpawnPoint>> groupSpawnPoints = new Dictionary<SpawnGroup, List<SpawnPoint>>();

    void Awake() {
        GenerateSpawnPoints();
    }

    void GenerateSpawnPoints() {
        groupSpawnPoints.Clear();
        
        if (spawnGroups == null) return;

        foreach (var group in spawnGroups) {
            if (!group.isEnabled || group.centerPoint == null) continue;

            List<SpawnPoint> points = new List<SpawnPoint>();
            groupSpawnPoints[group] = points;

            for (int i = 0; i < group.spawnCount; i++) {
                Vector2 randomCircle = Random.insideUnitCircle * group.radius;
                Vector3 offset = new Vector3(randomCircle.x, 0, randomCircle.y);
                Vector3 spawnPos = group.centerPoint.position + offset;
                points.Add(new SpawnPoint { 
                    position = spawnPos,
                    hasSpawned = false,
                    lastSpawnTime = 0f
                });
            }
        }
    }

    void Start() {
        // Set up default monsters array
        defaultMonsters = new GameObject[] { cricketmage, cricketwarrior, beetlewarrior };
        
        // Combine default and additional monsters
        List<GameObject> allMonsters = new List<GameObject>();
        
        // Add default monsters
        if (defaultMonsters != null) {
            foreach (GameObject monster in defaultMonsters) {
                if (monster != null) allMonsters.Add(monster);
            }
        }
        
        // Add additional monsters
        if (additionalMonsters != null) {
            foreach (GameObject monster in additionalMonsters) {
                if (monster != null) allMonsters.Add(monster);
            }
        }
        
        monsterPrefabs = allMonsters.ToArray();

        // Validate configuration
        if (spawnGroups == null || spawnGroups.Length == 0) {
            Debug.LogError("MonsterSpawner: No spawn groups configured!");
        }

        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update() {
        if (player == null) {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            if (player == null) return;
        }

        // Check each spawn group
        foreach (var group in spawnGroups) {
            if (!group.isEnabled || !groupSpawnPoints.ContainsKey(group)) continue;

            var spawnPoints = groupSpawnPoints[group];
            foreach (var sp in spawnPoints) {
                float distanceToPlayer = Vector3.Distance(sp.position, player.position);

                // Check if player is within trigger distance and enough time has passed
                if (!sp.hasSpawned && distanceToPlayer <= group.triggerDistance &&
                    Time.time - sp.lastSpawnTime >= minSpawnDelay) {
                    SpawnMonster(group, sp);
                }
                // Handle respawning if enabled
                else if (enableRespawn && sp.hasSpawned &&
                         Time.time - sp.lastSpawnTime >= respawnTime) {
                    sp.hasSpawned = false;
                }
            }
        }
    }

    void SpawnMonster(SpawnGroup group, SpawnPoint spawnPoint) {
        GameObject prefab = null;

        if (group.useAdditionalMonstersOnly) {
            // Only use additional monsters
            if (additionalMonsters != null && additionalMonsters.Length > 0) {
                prefab = additionalMonsters[Random.Range(0, additionalMonsters.Length)];
            }
        } else {
            // Check for additional monster chance
            bool useAdditional = Random.Range(0, 100) < group.additionalMonsterChance 
                               && additionalMonsters != null 
                               && additionalMonsters.Length > 0;

            if (useAdditional) {
                prefab = additionalMonsters[Random.Range(0, additionalMonsters.Length)];
            } else if (defaultMonsters != null && defaultMonsters.Length > 0) {
                prefab = defaultMonsters[Random.Range(0, defaultMonsters.Length)];
            }
        }

        if (prefab != null) {
            Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            spawnPoint.hasSpawned = true;
            spawnPoint.lastSpawnTime = Time.time;
        }
    }

    // Regenerate spawn points for a specific group
    public void RegenerateGroup(string groupName) {
        var group = System.Array.Find(spawnGroups, g => g.groupName == groupName);
        if (group != null) {
            groupSpawnPoints.Remove(group);
            if (group.isEnabled && group.centerPoint != null) {
                List<SpawnPoint> points = new List<SpawnPoint>();
                groupSpawnPoints[group] = points;
                // Generate new spawn points for this group
                for (int i = 0; i < group.spawnCount; i++) {
                    Vector2 randomCircle = Random.insideUnitCircle * group.radius;
                    Vector3 spawnPos = group.centerPoint.position + new Vector3(randomCircle.x, 0, randomCircle.y);
                    points.Add(new SpawnPoint { 
                        position = spawnPos,
                        hasSpawned = false,
                        lastSpawnTime = 0f
                    });
                }
            }
        }
    }

    void OnDrawGizmosSelected() {
        if (spawnGroups == null) return;

        foreach (var group in spawnGroups) {
            if (group?.centerPoint == null) continue;

            // Draw spawn radius
            Gizmos.color = group.isEnabled ? Color.green : Color.red;
            Gizmos.DrawWireSphere(group.centerPoint.position, group.radius);

            // Draw trigger distance
            Gizmos.color = new Color(0.5f, 0.5f, 1f, 0.3f);
            Gizmos.DrawWireSphere(group.centerPoint.position, group.triggerDistance);

            // Draw current spawn points if they exist
            if (groupSpawnPoints.ContainsKey(group)) {
                Gizmos.color = Color.yellow;
                foreach (var point in groupSpawnPoints[group]) {
                    Gizmos.DrawWireSphere(point.position, 0.5f);
                }
            }
        }
    }
}
