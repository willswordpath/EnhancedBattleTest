﻿using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.CustomBattle;

namespace EnhancedBattleTest.Data
{
    public class SerializedSceneData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public TerrainType Terrain { get; set; }
        public List<TerrainType> TerrainTypes { get; set; }
        public ForestDensity ForestDensity { get; set; }
        public bool IsSiegeMap { get; set; }
        public bool IsVillageMap { get; set; }

        public SerializedSceneData()
        { }

        public SerializedSceneData(SceneData data)
        {
            Id = data.Id ?? "";
            Name = data.Name?.ToString() ?? "";
            Terrain = data.Terrain;
            TerrainTypes = data.TerrainTypes;
            TerrainTypes ??= new List<TerrainType>();
            ForestDensity = data.ForestDensity;
            IsSiegeMap = data.IsSiegeMap;
            IsVillageMap = data.IsVillageMap;
        }
    }
    public class SceneData
    {
        public string Id { get; set; } = "";
        public TextObject Name { get; set; } = new TextObject();
        public TerrainType Terrain { get; set; }
        public List<TerrainType> TerrainTypes { get; set; }
        public ForestDensity ForestDensity { get; set; }
        public bool IsSiegeMap { get; set; }
        public bool IsVillageMap { get; set; }

        public SceneData()
        { }
        public SceneData(SerializedSceneData data)
        {
            Id = data.Id;
            Name = new TextObject(data.Name);
            Terrain = data.Terrain;
            TerrainTypes = data.TerrainTypes;
            TerrainTypes ??= new List<TerrainType>();
            ForestDensity = data.ForestDensity;
            IsSiegeMap = data.IsSiegeMap;
            IsVillageMap = data.IsVillageMap;
        }

        public SceneData(SingleplayerBattleSceneData data)
        {
            Id = data.SceneID;
            Name = new TextObject($"{data.SceneID} ({data.Terrain.ToString().ToLower()})");
            Terrain = data.Terrain;
            TerrainTypes = data.TerrainTypes;
            TerrainTypes ??= new List<TerrainType>();
            ForestDensity = data.ForestDensity;
            IsSiegeMap = false;
            IsVillageMap = false;
        }

        public SceneData(CustomBattleSceneData data)
        {
            Id = data.SceneID;
            Name = new TextObject(data.Name.ToString().ToLower());
            Terrain = data.Terrain;
            TerrainTypes = data.TerrainTypes;
            TerrainTypes ??= new List<TerrainType>();
            ForestDensity = data.ForestDensity;
            IsSiegeMap = data.IsSiegeMap;
            IsVillageMap = data.IsVillageMap;
        }
    }

    public class SceneDataComparer : IEqualityComparer<SceneData>
    {
        public bool Equals(SceneData x, SceneData y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.Terrain == y.Terrain && Equals(x.TerrainTypes, y.TerrainTypes) && x.ForestDensity == y.ForestDensity && x.IsSiegeMap == y.IsSiegeMap && x.IsVillageMap == y.IsVillageMap;
        }

        public int GetHashCode(SceneData obj)
        {
            unchecked
            {
                var hashCode = (obj.Id != null ? obj.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) obj.Terrain;
                hashCode = (hashCode * 397) ^ (obj.TerrainTypes != null ? obj.TerrainTypes.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) obj.ForestDensity;
                hashCode = (hashCode * 397) ^ obj.IsSiegeMap.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.IsVillageMap.GetHashCode();
                return hashCode;
            }
        }
    }
}
