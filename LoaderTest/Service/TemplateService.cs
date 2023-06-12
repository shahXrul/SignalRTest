using LoaderTest.DataAccess;
using LoaderTest.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaderTest.Service;

internal class TemplateService
{
    private readonly IConfiguration _configuration;
    private readonly SqlHelper _sqlHelper;

    public TemplateService(IConfiguration configuration, SqlHelper sqlHelper)
    {
        _sqlHelper = sqlHelper;
        _configuration = configuration;
    }

    public void Run()
    {
        //get batch
        var jobrequests = _sqlHelper.ExecuteDataTable("SELECT JobRequestId, itemcount, statusid, createdDate" +
                                    " FROM JobRequest WHERE statusid = 1 AND createdDate < DATEADD(minute, -2, GETDATE());");

        var jobrequests2 = _sqlHelper.Query<JobRequest>("SELECT JobRequestId, itemcount, statusid, createdDate" +
                                    " FROM JobRequest WHERE statusid = 1 AND createdDate < DATEADD(minute, -2, GETDATE());");
        //get template to process

    }
}


//commit tran
//unitOfWork.Complete();

////create job batch
//// var batchSize = jobtype.DefaultBatchSize;

//////split data to batch
//var batchList = objList

//            .Select((x, i) => new { Index = i, Value = x })
//            .GroupBy(x => x.Index / batchSize)
//            .Select(x => x.Select(v => v.Value).ToList())
//            .ToList();