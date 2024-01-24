namespace WebApplication1.Services
{
    public class DiscountService: IDiscountService
    {        
        private static int i = 0;
        public DiscountService()
        {
            ++i;
        }
        public string GetDiscountDescription() 
        {
            return "周年慶優惠實施中，全館打八折，滿千送百，不限金額，老闆不在，不學C#";
        }

        public int GetNumber()
        {
            return i;
        }
    }
}
