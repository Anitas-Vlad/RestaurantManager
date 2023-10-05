using RestaurantManagement.Models;
using RestaurantManagement.Models.Responses;

namespace RestaurantManagement.Services.Interfaces;

public interface ITableMapper
{
    TableResponse Map(Table table);
    List<TableResponse> Map(IEnumerable<Table> tables);
}