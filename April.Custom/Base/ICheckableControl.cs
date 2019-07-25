using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April.Custom.Base
{
    public interface ICheckableControl
    {
        /// <summary>
        /// Проверяет пустоту в компоненте. Выводит True если пустой.
        /// </summary>
        bool EmptyDataCheck { get; set; }

        /// <summary>
        /// Проверяет наличие данных в компоненте.
        /// </summary>
        /// <returns></returns>
        bool Check();
    }
}
