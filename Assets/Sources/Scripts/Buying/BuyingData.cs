using System;

[Serializable]
public class BuyingData
{
    public Product[] Products;
    public Product CurrentProduct;

    public BuyingData Construct(Product[] products, Product currentProduct)
    {
        Products = products;
        CurrentProduct = currentProduct;

        return this;
    }
}
