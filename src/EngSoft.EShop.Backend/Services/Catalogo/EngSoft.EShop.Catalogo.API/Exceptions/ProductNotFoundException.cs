namespace EngSoft.EShop.Catalogo.API.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Produto não encontrado!")
        {
            
        }
    }
}
