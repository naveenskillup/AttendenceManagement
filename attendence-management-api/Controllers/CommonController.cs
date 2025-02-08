using AttendenceManagementData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AttendenceManagementApi.Controllers
{
    public class CommonController : ControllerBase
    {
        public CommonController(AMSDBContext context) 
            => AMSDBContext = context;

        protected readonly AMSDBContext AMSDBContext;
    }
}
