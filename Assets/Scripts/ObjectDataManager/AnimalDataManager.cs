using Assets.Scripts.ObjectDataManager;
using System;
using UnityEngine;

public class AnimalDataManager : ObjectDataManager
    {
        private Vector3 position;
        public Vector3 Position { get { return position; } 
        
        }

    private void Start()
    {
        position = transform.position;
    }

    private int pointBonusRate;

         public int PointBonusRate
         {
             get { return pointBonusRate; }
             set { pointBonusRate = value; }
         }

        private int pointGachaBonusRate;
        public int PointGachaBonusRate
        {
            get { return pointGachaBonusRate;}
            set { pointGachaBonusRate = value; }
        }

        

        public void ConvertFromSerializedAnimalData(SerializedAnimalData animalData)
        {
            Id = animalData.NftId;

            PointBonusRate = animalData.PointBonusRate;

            PointGachaBonusRate = animalData.PointGachaBonusRate;

            maxHourForNextProvidingNutritions = animalData.MaxHoursForNextProvidedNutritions;

            Type = animalData.Type;

            if (animalData.LastTimeProvidingNutrition != null)
            {
                this.SetLastTimeProvidingNutrition(DateTime.Parse(animalData.LastTimeProvidingNutrition));
            }
            else
            {
                 this.SetLastTimeProvidingNutrition(DEFAULT_LAST_TIME_PROVIDING_NUTRITIONS);
            }

            if(animalData.Position != "" && animalData.Position != null)
             {
                transform.position = ConvertStringToVector3.StringToVector3 (animalData.Position);
            }

    }

    }

