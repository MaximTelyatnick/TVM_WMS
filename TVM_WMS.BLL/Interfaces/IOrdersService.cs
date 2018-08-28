using System;
using System.Collections.Generic;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<OrdersDTO> GetOrders(DateTime beginDate, DateTime endDate);
        IEnumerable<OrdersDTO> GetOrdersAcceptance();
        OrdersDTO GetOrderByReceiptId(int id);
        OrdersDTO GetOrderById(int id);

        int OrderCreate(OrdersDTO orddto);
        void OrderUpdate(OrdersDTO orddto);
        void UpdateRange(List<OrdersDTO> listorddto);

        Error.ErrorCRUD OrderDelete(OrdersDTO orddto);

        void Dispose();
    }
}
