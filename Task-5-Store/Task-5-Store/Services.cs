using Task_5_Store.Data;
using Task_5_Store.Factories;
using Task_5_Store.Repositories;
using Task_5_Store.Tools;

namespace Task_5_Store;

public class Services
{
    private ProductsData? _productsData;
    private CustomerFactory? _customerFactory;
    private CustomerRepository? _customerRepository;
    private ProductFactory? _productFactory;
    private ProductsRepository? _productsRepository;
    private Output? _output;
    private Input? _input;
    private Menu? _menu;

    public ProductsData ProductsData() => _productsData ??= new ProductsData();

    public CustomerFactory CustomerFactory() => _customerFactory ??= new CustomerFactory();

    public CustomerRepository CustomerRepository() =>
        _customerRepository ??= new CustomerRepository(CustomerFactory());

    public ProductFactory ProductFactory() => _productFactory ??= new ProductFactory();

    public ProductsRepository ProductsRepository() =>
        _productsRepository ??= new ProductsRepository(ProductsData(), ProductFactory());

    public Output Output() => _output ??= new Output();

    public Input Input() => _input ??= new Input(Output());

    public Menu Menu() => _menu ??= new Menu(this);
}