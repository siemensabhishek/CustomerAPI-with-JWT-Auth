using CrudOperation.CommonLayer.Model;
using System.Threading.Tasks;

namespace CrudOperation.ServiceLayer
{
    public interface ICrudOperationSL
    {
        Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);

        Task<ReadRecordResponse> ReadRecord();

        Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request);

        Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request);    
    }
}
