using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PoissonDiscSampling
{
    public static List<Vector3> Generate3D(float radius, Vector2 areaSize, int maxSamples = 30) {
        List<Vector2> points = Generate(radius, areaSize, maxSamples);
        List<Vector3> points3D = new List<Vector3>();

        foreach (Vector2 point in points) {
            Vector2 shiftedPoint = point - areaSize / 2;
            points3D.Add(new Vector3(shiftedPoint.x, 0, shiftedPoint.y));
        }

        return points3D;
    }

    public static List<Vector2> Generate(float radius, Vector2 areaSize, int maxSamples = 30) {
        // get cell size using Pythagoras c = radius / sqrt(2)
        float cellSize = radius / Mathf.Sqrt(2);

        // integer grid that maps to an index to points list
        int[,] grid = new int[Mathf.CeilToInt(areaSize.x / cellSize),
            Mathf.CeilToInt(areaSize.y / cellSize)];

        // holds sampled points maped to grid by its index
        List<Vector2> points = new List<Vector2>();
        List<Vector2> spawnPoints = new List<Vector2>();

        // adding intial spawn point
        spawnPoints.Add(areaSize/2);

        // starting sampling spawn points
        while (spawnPoints.Count > 0) {
            // picking random point to sample around
            int spawnIndex = Random.Range(0, spawnPoints.Count);
            Vector2 sapwnCenter = spawnPoints[spawnIndex];
            bool candidateAccepted = false;

            // trying to find valid point from spawn center
            for (int i = 0; i < maxSamples; i++) {
                // picking random direction
                float angle = Random.value * Mathf.PI * 2;
                Vector2 direction = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));

                // getting candidate position outside spawnCenter radius
                Vector2 candidate = sapwnCenter + direction * Random.Range(radius, radius * 2);

                if (IsValid(candidate, areaSize, cellSize, radius, points, grid)) {
                    points.Add(candidate);
                    spawnPoints.Add(candidate);
                    grid[(int) (candidate.x / cellSize), (int) (candidate.y / cellSize)] = points.Count;
                    candidateAccepted = true;
                    break;
                }
            }

            if (!candidateAccepted) {
                spawnPoints.RemoveAt(spawnIndex);
            }
        }

        return points;
    }

    private static bool IsValid(Vector2 candidate, Vector2 areaSize, float cellSize, float radius,
        List<Vector2> points, int[,] grid) {
        bool insideArea = candidate.x >= 0 && candidate.x < areaSize.x && candidate.y >= 0 &&
                          candidate.y < areaSize.y;
        if (!insideArea) return false;

        int cellX = (int) (candidate.x / cellSize);
        int cellY = (int) (candidate.y / cellSize);

        // setting search kernel intervals
        int searchStartX = Mathf.Max(0, cellX - 2);
        int searchEndX = Mathf.Min(cellX + 2, grid.GetLength(0)-1);
        int searchStartY = Mathf.Max(0, cellY - 2);
        int searchEndY = Mathf.Min(cellY + 2, grid.GetLength(1)-1);

        for (int x = searchStartX; x <= searchEndX; x++) {
            for (int y = searchStartY; y <= searchEndY; y++) {
                int pointIndex = grid[x, y] - 1;
                if (pointIndex != -1) {
                    // check if candidate is outside point radius
                    float sqrtDistance = (candidate - points[pointIndex]).sqrMagnitude;
                    if (sqrtDistance < radius * radius) {
                        return false;
                    }
                }
            }
        }

        return true;
    }
}
