using System;

public class BuyingData 
{
    public Product[] Products;
    public Product CurrentProduct;

    public BuyingData(Product[] products, Product currentProduct)
    {
        Products = products;
        CurrentProduct = currentProduct;
    }
}