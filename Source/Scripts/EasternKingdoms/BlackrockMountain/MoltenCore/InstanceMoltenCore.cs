/*
 * Copyright (C) 2012-2020 CypherCore <http://github.com/CypherCore>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Framework.Constants;
using Game.Entities;
using Game.Maps;
using Game.Scripting;
using System;

namespace Scripts.EasternKingdoms.BlackrockMountain.MoltenCore
{
    struct BossIds
    {
        public const uint Lucifron = 0;
        public const uint Magmadar = 1;
        public const uint Gehennas = 2;
        public const uint Garr = 3;
        public const uint Shazzrah = 4;
        public const uint BaronGeddon = 5;
        public const uint SulfuronHarbinger = 6;
        public const uint GolemaggTheIncinerator = 7;
        public const uint MajordomoExecutus = 8;
        public const uint Ragnaros = 9;

        public const uint MaxEncounter = 10;
    }

    struct ActionIds
    {
        public const int StartRagnaros = 0;
        public const int StartRagnarosAlt = 1;
    }

    struct MCCreatureIds
    {
        public const uint Lucifron = 12118;
        public const uint Magmadar = 11982;
        public const uint Gehennas = 12259;
        public const uint Garr = 12057;
        public const uint Shazzrah = 12264;
        public const uint BaronGeddon = 12056;
        public const uint SulfuronHarbinger = 12098;
        public const uint GolemaggTheIncinerator = 11988;
        public const uint MajordomoExecutus = 12018;
        public const uint Ragnaros = 11502;
        public const uint FlamewakerHealer = 11663;
        public const uint FlamewakerElite = 11664;
    }

    struct MCGameObjectIds
    {
        public const uint CacheOfTheFirelord = 179703;
    }

    struct MCMiscConst
    {
        public const uint DataRagnarosAdds = 0;

        public static Position[] SummonPositions =
        {
            new Position(737.850f, -1145.35f, -120.288f, 4.71368f),
            new Position(744.162f, -1151.63f, -119.726f, 4.58204f),
            new Position(751.247f, -1152.82f, -119.744f, 4.49673f),
            new Position(759.206f, -1155.09f, -120.051f, 4.30104f),
            new Position(755.973f, -1152.33f, -120.029f, 4.25588f),
            new Position(731.712f, -1147.56f, -120.195f, 4.95955f),
            new Position(726.499f, -1149.80f, -120.156f, 5.24055f),
            new Position(722.408f, -1152.41f, -120.029f, 5.33087f),
            new Position(718.994f, -1156.36f, -119.805f, 5.75738f),
            new Position(838.510f, -829.840f, -232.000f, 2.00000f),
        };

        public static Position RagnarosTelePos = new Position(829.159f, -815.773f, -228.972f, 5.30500f);
        public static Position RagnarosSummonPos = new Position(838.510f, -829.840f, -232.000f, 2.00000f);
    }

    [Script]
    class instance_molten_core : InstanceMapScript
    {
        public instance_molten_core() : base(nameof(instance_molten_core), 409) { }

        class instance_molten_core_InstanceMapScript : InstanceScript
        {
            ObjectGuid _golemaggTheIncineratorGUID;
            ObjectGuid _majordomoExecutusGUID;
            ObjectGuid _cacheOfTheFirelordGUID;
            bool _executusSchedule;
            byte _ragnarosAddDeaths;

            public instance_molten_core_InstanceMapScript(InstanceMap map) : base(map)
            {
                SetHeaders("MC");
                SetBossNumber(BossIds.MaxEncounter);
                _executusSchedule = false;
                _ragnarosAddDeaths = 0;
            }

            public override void OnPlayerEnter(Player player)
            {
                if (_executusSchedule)
                    SummonMajordomoExecutus();
            }

            public override void OnCreatureCreate(Creature creature)
            {
                switch (creature.GetEntry())
                {
                    case MCCreatureIds.GolemaggTheIncinerator:
                        _golemaggTheIncineratorGUID = creature.GetGUID();
                        break;
                    case MCCreatureIds.MajordomoExecutus:
                        _majordomoExecutusGUID = creature.GetGUID();
                        break;
                    default:
                        break;
                }
            }

            public override void OnGameObjectCreate(GameObject go)
            {
                switch (go.GetEntry())
                {
                    case MCGameObjectIds.CacheOfTheFirelord:
                        _cacheOfTheFirelordGUID = go.GetGUID();
                        break;
                    default:
                        break;
                }
            }

            public override void SetData(uint type, uint data)
            {
                if (type == MCMiscConst.DataRagnarosAdds)
                {
                    if (data == 1)
                        ++_ragnarosAddDeaths;
                    else if (data == 0)
                        _ragnarosAddDeaths = 0;
                }
            }

            public override uint GetData(uint type)
            {
                switch (type)
                {
                    case MCMiscConst.DataRagnarosAdds:
                        return _ragnarosAddDeaths;
                }

                return 0;
            }

            public override ObjectGuid GetGuidData(uint type)
            {
                switch (type)
                {
                    case BossIds.GolemaggTheIncinerator:
                        return _golemaggTheIncineratorGUID;
                    case BossIds.MajordomoExecutus:
                        return _majordomoExecutusGUID;
                }

                return ObjectGuid.Empty;
            }

            public override bool SetBossState(uint bossId, EncounterState state)
            {
                if (!base.SetBossState(bossId, state))
                    return false;

                if (state == EncounterState.Done && bossId < BossIds.MajordomoExecutus)
                    if (CheckMajordomoExecutus())
                        SummonMajordomoExecutus();

                if (bossId == BossIds.MajordomoExecutus && state == EncounterState.Done)
                    DoRespawnGameObject(_cacheOfTheFirelordGUID, TimeSpan.FromDays(7));

                return true;
            }

            void SummonMajordomoExecutus()
            {
                _executusSchedule = false;
                if (!_majordomoExecutusGUID.IsEmpty())
                    return;

                if (GetBossState(BossIds.MajordomoExecutus) != EncounterState.Done)
                {
                    instance.SummonCreature(MCCreatureIds.MajordomoExecutus, MCMiscConst.SummonPositions[0]);
                    instance.SummonCreature(MCCreatureIds.FlamewakerHealer, MCMiscConst.SummonPositions[1]);
                    instance.SummonCreature(MCCreatureIds.FlamewakerHealer, MCMiscConst.SummonPositions[2]);
                    instance.SummonCreature(MCCreatureIds.FlamewakerHealer, MCMiscConst.SummonPositions[3]);
                    instance.SummonCreature(MCCreatureIds.FlamewakerHealer, MCMiscConst.SummonPositions[4]);
                    instance.SummonCreature(MCCreatureIds.FlamewakerElite, MCMiscConst.SummonPositions[5]);
                    instance.SummonCreature(MCCreatureIds.FlamewakerElite, MCMiscConst.SummonPositions[6]);
                    instance.SummonCreature(MCCreatureIds.FlamewakerElite, MCMiscConst.SummonPositions[7]);
                    instance.SummonCreature(MCCreatureIds.FlamewakerElite, MCMiscConst.SummonPositions[8]);
                }
                else
                {
                    TempSummon summon = instance.SummonCreature(MCCreatureIds.MajordomoExecutus, MCMiscConst.RagnarosTelePos);
                    if (summon)
                        summon.GetAI().DoAction(ActionIds.StartRagnarosAlt);
                }
            }

            bool CheckMajordomoExecutus()
            {
                if (GetBossState(BossIds.Ragnaros) == EncounterState.Done)
                    return false;

                for (byte i = 0; i < BossIds.MajordomoExecutus; ++i)
                    if (GetBossState(i) != EncounterState.Done)
                        return false;

                return true;
            }

            void ReadSaveDataMore(string data)
            {
                if (CheckMajordomoExecutus())
                    _executusSchedule = true;
            }
        }

        public override InstanceScript GetInstanceScript(InstanceMap map)
        {
            return new instance_molten_core_InstanceMapScript(map);
        }
    }
}
