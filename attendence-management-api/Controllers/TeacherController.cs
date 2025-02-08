using AttendenceManagementData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementApi.Controllers
{

    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : CommonController
    {

        public TeacherController(AMSDBContext context) : base(context) 
        { }


    }

}
