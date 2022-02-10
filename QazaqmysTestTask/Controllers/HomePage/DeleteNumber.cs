using QazaqmysTestTask.Models.Repositry;

namespace QazaqmysTestTask.Controllers.HomePage
{
    public static class DeleteNumber
    {
        private static NumberRepository numberRepository = new NumberRepository();

        public static void Execute(long ID)
        {
            numberRepository.Delete(ID);
        }
    }
}
