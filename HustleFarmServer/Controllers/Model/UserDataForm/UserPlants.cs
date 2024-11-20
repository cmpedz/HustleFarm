namespace HustleFarmServer.Controllers.Model.UserDataForm
{

    [System.Serializable]
    public class UserPlants
    {
        public static readonly string PlantsField = "Plants";
        public List<PlantData>? Plants {  get; set; }
    }
}
