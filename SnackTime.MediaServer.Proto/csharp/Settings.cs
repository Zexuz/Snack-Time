// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proto/settings.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SnackTime.App.Settings.ProtoGenerated {

  /// <summary>Holder for reflection information generated from proto/settings.proto</summary>
  public static partial class SettingsReflection {

    #region Descriptor
    /// <summary>File descriptor for proto/settings.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SettingsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChRwcm90by9zZXR0aW5ncy5wcm90bxIWc25hY2t0aW1lLmFwcC5zZXR0aW5n",
            "cyJvCghTZXR0aW5ncxIzCgZzeXN0ZW0YASABKAsyIy5zbmFja3RpbWUuYXBw",
            "LnNldHRpbmdzLkxvY2FsU3lzdGVtEi4KBnJlbW90ZRgCIAEoCzIeLnNuYWNr",
            "dGltZS5hcHAuc2V0dGluZ3MuUmVtb3RlIlUKC0xvY2FsU3lzdGVtEg8KB2Zp",
            "bGVEaXIYASABKAkSEwoLdGVtcEZpbGVEaXIYAiABKAkSDwoHbXB2UGF0aBgD",
            "IAEoCRIPCgdzdnBQYXRoGAQgASgJIjYKBlJlbW90ZRIaChJtZWRpYVNlcnZl",
            "ckFkZHJlc3MYASABKAkSEAoIaXNPbmxpbmUYAiABKAhCKKoCJVNuYWNrVGlt",
            "ZS5BcHAuU2V0dGluZ3MuUHJvdG9HZW5lcmF0ZWRiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SnackTime.App.Settings.ProtoGenerated.Settings), global::SnackTime.App.Settings.ProtoGenerated.Settings.Parser, new[]{ "System", "Remote" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SnackTime.App.Settings.ProtoGenerated.LocalSystem), global::SnackTime.App.Settings.ProtoGenerated.LocalSystem.Parser, new[]{ "FileDir", "TempFileDir", "MpvPath", "SvpPath" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SnackTime.App.Settings.ProtoGenerated.Remote), global::SnackTime.App.Settings.ProtoGenerated.Remote.Parser, new[]{ "MediaServerAddress", "IsOnline" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Settings : pb::IMessage<Settings> {
    private static readonly pb::MessageParser<Settings> _parser = new pb::MessageParser<Settings>(() => new Settings());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Settings> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SnackTime.App.Settings.ProtoGenerated.SettingsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Settings() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Settings(Settings other) : this() {
      system_ = other.system_ != null ? other.system_.Clone() : null;
      remote_ = other.remote_ != null ? other.remote_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Settings Clone() {
      return new Settings(this);
    }

    /// <summary>Field number for the "system" field.</summary>
    public const int SystemFieldNumber = 1;
    private global::SnackTime.App.Settings.ProtoGenerated.LocalSystem system_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SnackTime.App.Settings.ProtoGenerated.LocalSystem System {
      get { return system_; }
      set {
        system_ = value;
      }
    }

    /// <summary>Field number for the "remote" field.</summary>
    public const int RemoteFieldNumber = 2;
    private global::SnackTime.App.Settings.ProtoGenerated.Remote remote_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SnackTime.App.Settings.ProtoGenerated.Remote Remote {
      get { return remote_; }
      set {
        remote_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Settings);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Settings other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(System, other.System)) return false;
      if (!object.Equals(Remote, other.Remote)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (system_ != null) hash ^= System.GetHashCode();
      if (remote_ != null) hash ^= Remote.GetHashCode();
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
      if (system_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(System);
      }
      if (remote_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Remote);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (system_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(System);
      }
      if (remote_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Remote);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Settings other) {
      if (other == null) {
        return;
      }
      if (other.system_ != null) {
        if (system_ == null) {
          system_ = new global::SnackTime.App.Settings.ProtoGenerated.LocalSystem();
        }
        System.MergeFrom(other.System);
      }
      if (other.remote_ != null) {
        if (remote_ == null) {
          remote_ = new global::SnackTime.App.Settings.ProtoGenerated.Remote();
        }
        Remote.MergeFrom(other.Remote);
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
          case 10: {
            if (system_ == null) {
              system_ = new global::SnackTime.App.Settings.ProtoGenerated.LocalSystem();
            }
            input.ReadMessage(system_);
            break;
          }
          case 18: {
            if (remote_ == null) {
              remote_ = new global::SnackTime.App.Settings.ProtoGenerated.Remote();
            }
            input.ReadMessage(remote_);
            break;
          }
        }
      }
    }

  }

  public sealed partial class LocalSystem : pb::IMessage<LocalSystem> {
    private static readonly pb::MessageParser<LocalSystem> _parser = new pb::MessageParser<LocalSystem>(() => new LocalSystem());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LocalSystem> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SnackTime.App.Settings.ProtoGenerated.SettingsReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LocalSystem() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LocalSystem(LocalSystem other) : this() {
      fileDir_ = other.fileDir_;
      tempFileDir_ = other.tempFileDir_;
      mpvPath_ = other.mpvPath_;
      svpPath_ = other.svpPath_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LocalSystem Clone() {
      return new LocalSystem(this);
    }

    /// <summary>Field number for the "fileDir" field.</summary>
    public const int FileDirFieldNumber = 1;
    private string fileDir_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FileDir {
      get { return fileDir_; }
      set {
        fileDir_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "tempFileDir" field.</summary>
    public const int TempFileDirFieldNumber = 2;
    private string tempFileDir_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string TempFileDir {
      get { return tempFileDir_; }
      set {
        tempFileDir_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "mpvPath" field.</summary>
    public const int MpvPathFieldNumber = 3;
    private string mpvPath_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string MpvPath {
      get { return mpvPath_; }
      set {
        mpvPath_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "svpPath" field.</summary>
    public const int SvpPathFieldNumber = 4;
    private string svpPath_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string SvpPath {
      get { return svpPath_; }
      set {
        svpPath_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LocalSystem);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LocalSystem other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (FileDir != other.FileDir) return false;
      if (TempFileDir != other.TempFileDir) return false;
      if (MpvPath != other.MpvPath) return false;
      if (SvpPath != other.SvpPath) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (FileDir.Length != 0) hash ^= FileDir.GetHashCode();
      if (TempFileDir.Length != 0) hash ^= TempFileDir.GetHashCode();
      if (MpvPath.Length != 0) hash ^= MpvPath.GetHashCode();
      if (SvpPath.Length != 0) hash ^= SvpPath.GetHashCode();
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
      if (FileDir.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(FileDir);
      }
      if (TempFileDir.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(TempFileDir);
      }
      if (MpvPath.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(MpvPath);
      }
      if (SvpPath.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(SvpPath);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (FileDir.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(FileDir);
      }
      if (TempFileDir.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(TempFileDir);
      }
      if (MpvPath.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MpvPath);
      }
      if (SvpPath.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(SvpPath);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LocalSystem other) {
      if (other == null) {
        return;
      }
      if (other.FileDir.Length != 0) {
        FileDir = other.FileDir;
      }
      if (other.TempFileDir.Length != 0) {
        TempFileDir = other.TempFileDir;
      }
      if (other.MpvPath.Length != 0) {
        MpvPath = other.MpvPath;
      }
      if (other.SvpPath.Length != 0) {
        SvpPath = other.SvpPath;
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
          case 10: {
            FileDir = input.ReadString();
            break;
          }
          case 18: {
            TempFileDir = input.ReadString();
            break;
          }
          case 26: {
            MpvPath = input.ReadString();
            break;
          }
          case 34: {
            SvpPath = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class Remote : pb::IMessage<Remote> {
    private static readonly pb::MessageParser<Remote> _parser = new pb::MessageParser<Remote>(() => new Remote());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Remote> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SnackTime.App.Settings.ProtoGenerated.SettingsReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Remote() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Remote(Remote other) : this() {
      mediaServerAddress_ = other.mediaServerAddress_;
      isOnline_ = other.isOnline_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Remote Clone() {
      return new Remote(this);
    }

    /// <summary>Field number for the "mediaServerAddress" field.</summary>
    public const int MediaServerAddressFieldNumber = 1;
    private string mediaServerAddress_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string MediaServerAddress {
      get { return mediaServerAddress_; }
      set {
        mediaServerAddress_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "isOnline" field.</summary>
    public const int IsOnlineFieldNumber = 2;
    private bool isOnline_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool IsOnline {
      get { return isOnline_; }
      set {
        isOnline_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Remote);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Remote other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MediaServerAddress != other.MediaServerAddress) return false;
      if (IsOnline != other.IsOnline) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MediaServerAddress.Length != 0) hash ^= MediaServerAddress.GetHashCode();
      if (IsOnline != false) hash ^= IsOnline.GetHashCode();
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
      if (MediaServerAddress.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(MediaServerAddress);
      }
      if (IsOnline != false) {
        output.WriteRawTag(16);
        output.WriteBool(IsOnline);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (MediaServerAddress.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MediaServerAddress);
      }
      if (IsOnline != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Remote other) {
      if (other == null) {
        return;
      }
      if (other.MediaServerAddress.Length != 0) {
        MediaServerAddress = other.MediaServerAddress;
      }
      if (other.IsOnline != false) {
        IsOnline = other.IsOnline;
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
          case 10: {
            MediaServerAddress = input.ReadString();
            break;
          }
          case 16: {
            IsOnline = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
