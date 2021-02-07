using AutoMapper;

public class AutoMapping : Profile
{

    public AutoMapping()
    {
        CreateMap<Order, OrderDTO>();
        CreateMap<OrderDTO, Order>();

        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>();

        CreateMap<Order_Detail, Order_DetailDTO>();
        CreateMap<Order_DetailDTO, Order_Detail>();

    }
}