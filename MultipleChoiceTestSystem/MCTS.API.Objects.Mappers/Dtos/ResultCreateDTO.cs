namespace MCTS.API.Objects.Mappers.Dtos
{
    public class ResultCreateDTO
    {
        public int RightAnswerCt { get; set; }
        public int WrongAnswerCt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
