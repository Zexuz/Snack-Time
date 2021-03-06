// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proto/series-service/series-service.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace SnackTime.MediaServer.Service.Series {
  public static partial class Series
  {
    static readonly string __ServiceName = "snacktime.series.service.Series";

    static readonly grpc::Marshaller<global::SnackTime.MediaServer.Service.Series.GetLastDownloadedRequest> __Marshaller_snacktime_series_service_GetLastDownloadedRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::SnackTime.MediaServer.Service.Series.GetLastDownloadedRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::SnackTime.MediaServer.Service.Series.GetLastDownloadedResponse> __Marshaller_snacktime_series_service_GetLastDownloadedResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::SnackTime.MediaServer.Service.Series.GetLastDownloadedResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::SnackTime.MediaServer.Service.Series.GetAllRequest> __Marshaller_snacktime_series_service_GetAllRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::SnackTime.MediaServer.Service.Series.GetAllRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::SnackTime.MediaServer.Service.Series.GetAllResponse> __Marshaller_snacktime_series_service_GetAllResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::SnackTime.MediaServer.Service.Series.GetAllResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::SnackTime.MediaServer.Service.Series.GetByIdRequest> __Marshaller_snacktime_series_service_GetByIdRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::SnackTime.MediaServer.Service.Series.GetByIdRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::SnackTime.MediaServer.Service.Series.GetByIdResponse> __Marshaller_snacktime_series_service_GetByIdResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::SnackTime.MediaServer.Service.Series.GetByIdResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::SnackTime.MediaServer.Service.Series.GetLastDownloadedRequest, global::SnackTime.MediaServer.Service.Series.GetLastDownloadedResponse> __Method_GetLastDownloaded = new grpc::Method<global::SnackTime.MediaServer.Service.Series.GetLastDownloadedRequest, global::SnackTime.MediaServer.Service.Series.GetLastDownloadedResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetLastDownloaded",
        __Marshaller_snacktime_series_service_GetLastDownloadedRequest,
        __Marshaller_snacktime_series_service_GetLastDownloadedResponse);

    static readonly grpc::Method<global::SnackTime.MediaServer.Service.Series.GetAllRequest, global::SnackTime.MediaServer.Service.Series.GetAllResponse> __Method_GetAll = new grpc::Method<global::SnackTime.MediaServer.Service.Series.GetAllRequest, global::SnackTime.MediaServer.Service.Series.GetAllResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAll",
        __Marshaller_snacktime_series_service_GetAllRequest,
        __Marshaller_snacktime_series_service_GetAllResponse);

    static readonly grpc::Method<global::SnackTime.MediaServer.Service.Series.GetByIdRequest, global::SnackTime.MediaServer.Service.Series.GetByIdResponse> __Method_GetById = new grpc::Method<global::SnackTime.MediaServer.Service.Series.GetByIdRequest, global::SnackTime.MediaServer.Service.Series.GetByIdResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetById",
        __Marshaller_snacktime_series_service_GetByIdRequest,
        __Marshaller_snacktime_series_service_GetByIdResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::SnackTime.MediaServer.Service.Series.SeriesServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Series</summary>
    public abstract partial class SeriesBase
    {
      public virtual global::System.Threading.Tasks.Task<global::SnackTime.MediaServer.Service.Series.GetLastDownloadedResponse> GetLastDownloaded(global::SnackTime.MediaServer.Service.Series.GetLastDownloadedRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::SnackTime.MediaServer.Service.Series.GetAllResponse> GetAll(global::SnackTime.MediaServer.Service.Series.GetAllRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::SnackTime.MediaServer.Service.Series.GetByIdResponse> GetById(global::SnackTime.MediaServer.Service.Series.GetByIdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for Series</summary>
    public partial class SeriesClient : grpc::ClientBase<SeriesClient>
    {
      /// <summary>Creates a new client for Series</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public SeriesClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Series that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public SeriesClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected SeriesClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected SeriesClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::SnackTime.MediaServer.Service.Series.GetLastDownloadedResponse GetLastDownloaded(global::SnackTime.MediaServer.Service.Series.GetLastDownloadedRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetLastDownloaded(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::SnackTime.MediaServer.Service.Series.GetLastDownloadedResponse GetLastDownloaded(global::SnackTime.MediaServer.Service.Series.GetLastDownloadedRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetLastDownloaded, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::SnackTime.MediaServer.Service.Series.GetLastDownloadedResponse> GetLastDownloadedAsync(global::SnackTime.MediaServer.Service.Series.GetLastDownloadedRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetLastDownloadedAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::SnackTime.MediaServer.Service.Series.GetLastDownloadedResponse> GetLastDownloadedAsync(global::SnackTime.MediaServer.Service.Series.GetLastDownloadedRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetLastDownloaded, null, options, request);
      }
      public virtual global::SnackTime.MediaServer.Service.Series.GetAllResponse GetAll(global::SnackTime.MediaServer.Service.Series.GetAllRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAll(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::SnackTime.MediaServer.Service.Series.GetAllResponse GetAll(global::SnackTime.MediaServer.Service.Series.GetAllRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAll, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::SnackTime.MediaServer.Service.Series.GetAllResponse> GetAllAsync(global::SnackTime.MediaServer.Service.Series.GetAllRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::SnackTime.MediaServer.Service.Series.GetAllResponse> GetAllAsync(global::SnackTime.MediaServer.Service.Series.GetAllRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAll, null, options, request);
      }
      public virtual global::SnackTime.MediaServer.Service.Series.GetByIdResponse GetById(global::SnackTime.MediaServer.Service.Series.GetByIdRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetById(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::SnackTime.MediaServer.Service.Series.GetByIdResponse GetById(global::SnackTime.MediaServer.Service.Series.GetByIdRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetById, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::SnackTime.MediaServer.Service.Series.GetByIdResponse> GetByIdAsync(global::SnackTime.MediaServer.Service.Series.GetByIdRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetByIdAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::SnackTime.MediaServer.Service.Series.GetByIdResponse> GetByIdAsync(global::SnackTime.MediaServer.Service.Series.GetByIdRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetById, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override SeriesClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new SeriesClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(SeriesBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetLastDownloaded, serviceImpl.GetLastDownloaded)
          .AddMethod(__Method_GetAll, serviceImpl.GetAll)
          .AddMethod(__Method_GetById, serviceImpl.GetById).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SeriesBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetLastDownloaded, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::SnackTime.MediaServer.Service.Series.GetLastDownloadedRequest, global::SnackTime.MediaServer.Service.Series.GetLastDownloadedResponse>(serviceImpl.GetLastDownloaded));
      serviceBinder.AddMethod(__Method_GetAll, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::SnackTime.MediaServer.Service.Series.GetAllRequest, global::SnackTime.MediaServer.Service.Series.GetAllResponse>(serviceImpl.GetAll));
      serviceBinder.AddMethod(__Method_GetById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::SnackTime.MediaServer.Service.Series.GetByIdRequest, global::SnackTime.MediaServer.Service.Series.GetByIdResponse>(serviceImpl.GetById));
    }

  }
}
#endregion
