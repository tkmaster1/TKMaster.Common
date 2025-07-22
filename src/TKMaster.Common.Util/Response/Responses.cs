using TKMaster.Common.Domain.Entities;

namespace TKMaster.Common.Util.Response;

public class ResponseSuccess<T>
{
    public bool Success { get; set; }

    public T Data { get; set; }
}

public class ResponseFailure
{
    public bool Success { get; set; }

    public IEnumerable<string> Errors { get; set; }

}

public class ResponseBaseEntity : ResponseSuccess<Entity>
{
}