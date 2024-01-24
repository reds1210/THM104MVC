namespace WebApplication1.Services
{
    public class XrmsService : IDiscountService
    {
        public string GetDiscountDescription()
        {
            return "歡慶聖誕節與跨年到來，黑浮咖啡即日起～12/31全台實體門市消費滿1,500元，立刻免費送「草莓法芙娜花圈白玉麻糬鬆餅」（價值390元）";
        }

        public int GetNumber()
        {
            throw new NotImplementedException();
        }
    }
}
