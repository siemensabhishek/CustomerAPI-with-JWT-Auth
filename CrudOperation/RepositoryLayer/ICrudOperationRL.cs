using CrudOperation.CommonLayer.Model;
using System.Threading.Tasks;

namespace CrudOperation.RepositoryLayer
{
    public interface ICrudOperationRL
    {
         Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);

         Task<ReadRecordResponse> ReadRecord();

        Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request);
        Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request);
    }
}
