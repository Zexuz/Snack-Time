// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proto/series-service/series-getLastDownloaded.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SnackTime.MediaServer.Service.Series {

  /// <summary>Holder for reflection information generated from proto/series-service/series-getLastDownloaded.proto</summary>
  public static partial class SeriesGetLastDownloadedReflection {

    #region Descriptor
    /// <summary>File descriptor for proto/series-service/series-getLastDownloaded.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SeriesGetLastDownloadedReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjNwcm90by9zZXJpZXMtc2VydmljZS9zZXJpZXMtZ2V0TGFzdERvd25sb2Fk",
            "ZWQucHJvdG8SGHNuYWNrdGltZS5zZXJpZXMuc2VydmljZRoRcHJvdG8vbWVk",
            "aWEucHJvdG8iGgoYR2V0TGFzdERvd25sb2FkZWRSZXF1ZXN0IkQKGUdldExh",
            "c3REb3dubG9hZGVkUmVzcG9uc2USJwoGc2VyaWVzGAEgAygLMhcuc25hY2t0",
            "aW1lLm1lZGlhLlNlcmllc0InqgIkU25hY2tUaW1lLk1lZGlhU2VydmVyLlNl",
            "cnZpY2UuU2VyaWVzYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::SnackTime.MediaServer.Models.ProtoGenerated.MediaReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SnackTime.MediaServer.Service.Series.GetLastDownloadedRequest), global::SnackTime.MediaServer.Service.Series.GetLastDownloadedRequest.Parser, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SnackTime.MediaServer.Service.Series.GetLastDownloadedResponse), global::SnackTime.MediaServer.Service.Series.GetLastDownloadedResponse.Parser, new[]{ "Series" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GetLastDownloadedRequest : pb::IMessage<GetLastDownloadedRequest> {
    private static readonly pb::MessageParser<GetLastDownloadedRequest> _parser = new pb::MessageParser<GetLastDownloadedRequest>(() => new GetLastDownloadedRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetLastDownloadedRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SnackTime.MediaServer.Service.Series.SeriesGetLastDownloadedReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetLastDownloadedRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetLastDownloadedRequest(GetLastDownloadedRequest other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetLastDownloadedRequest Clone() {
      return new GetLastDownloadedRequest(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetLastDownloadedRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetLastDownloadedRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetLastDownloadedRequest other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    }

  }

  public sealed partial class GetLastDownloadedResponse : pb::IMessage<GetLastDownloadedResponse> {
    private static readonly pb::MessageParser<GetLastDownloadedResponse> _parser = new pb::MessageParser<GetLastDownloadedResponse>(() => new GetLastDownloadedResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetLastDownloadedResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SnackTime.MediaServer.Service.Series.SeriesGetLastDownloadedReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetLastDownloadedResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetLastDownloadedResponse(GetLastDownloadedResponse other) : this() {
      series_ = other.series_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetLastDownloadedResponse Clone() {
      return new GetLastDownloadedResponse(this);
    }

    /// <summary>Field number for the "series" field.</summary>
    public const int SeriesFieldNumber = 1;
    private static readonly pb::FieldCodec<global::SnackTime.MediaServer.Models.ProtoGenerated.Series> _repeated_series_codec
        = pb::FieldCodec.ForMessage(10, global::SnackTime.MediaServer.Models.ProtoGenerated.Series.Parser);
    private readonly pbc::RepeatedField<global::SnackTime.MediaServer.Models.ProtoGenerated.Series> series_ = new pbc::RepeatedField<global::SnackTime.MediaServer.Models.ProtoGenerated.Series>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::SnackTime.MediaServer.Models.ProtoGenerated.Series> Series {
      get { return series_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetLastDownloadedResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetLastDownloadedResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!series_.Equals(other.series_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= series_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      series_.WriteTo(output, _repeated_series_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += series_.CalculateSize(_repeated_series_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetLastDownloadedResponse other) {
      if (other == null) {
        return;
      }
      series_.Add(other.series_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            series_.AddEntriesFrom(input, _repeated_series_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code