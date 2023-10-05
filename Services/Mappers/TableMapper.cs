using RestaurantManagement.Models.Responses;
using RestaurantManagement.Services.Interfaces;
using Table = RestaurantManagement.Models.Table;

namespace RestaurantManagement.Services.Mappers;

public class TableMapper
{
    public ITableDishMapper _tableDishMapper;

    public TableMapper(ITableDishMapper tableDishMapper)
    {
        _tableDishMapper = tableDishMapper;
    }
    
    public TableResponse Map(Table table) =>
        new()
        {
            Id = table.Id,
            IsAvailable = table.isAvailable,
            Number = table.Number,
            TableDishes = _tableDishMapper.Map(table.TableDishes),
            TotalPrice = table.TotalPrice
        };

    public List<TableResponse> Map(IEnumerable<Table> tables)
        => tables.Select(Map).ToList();
}