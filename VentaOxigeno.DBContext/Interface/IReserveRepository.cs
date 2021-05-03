using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IReserveRepository
    {
        BaseResponse GetReserves();

        BaseResponse GetReserve(int id);

        BaseResponse GetReservePrice(decimal price_min, decimal price_max, string direccion);

        BaseResponse Insert(EntityReserve reserve);
    }
}
