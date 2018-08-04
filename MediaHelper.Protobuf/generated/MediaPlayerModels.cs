// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: MediaPlayerModels.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace LocalNetflix.Protobuf.MediaPlayerModels {

  /// <summary>Holder for reflection information generated from MediaPlayerModels.proto</summary>
  public static partial class MediaPlayerModelsReflection {

    #region Descriptor
    /// <summary>File descriptor for MediaPlayerModels.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MediaPlayerModelsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChdNZWRpYVBsYXllck1vZGVscy5wcm90bxIRTWVkaWFQbGF5ZXJNb2RlbHMi",
            "cQoQUGxheWluZ01lZGlhSW5mbxIQCghGaWxlTmFtZRgBIAEoCRIQCghEdXJh",
            "dGlvbhgCIAEoARIQCghFcGxpcHNlZBgDIAEoARInCgVTdGF0ZRgEIAEoDjIY",
            "Lk1lZGlhUGxheWVyTW9kZWxzLlN0YXRlIhwKCE9wZW5GaWxlEhAKCEZpbGVO",
            "YW1lGAEgASgJIowCChdQbGF5aW5nTWVkaWFJbmZvQ2hhbmdlZBI2CglNZWRp",
            "YUluZm8YASABKAsyIy5NZWRpYVBsYXllck1vZGVscy5QbGF5aW5nTWVkaWFJ",
            "bmZvEjkKDE9sZE1lZGlhSW5mbxgCIAEoCzIjLk1lZGlhUGxheWVyTW9kZWxz",
            "LlBsYXlpbmdNZWRpYUluZm8SSgoIUHJvcGVydHkYAyABKA4yOC5NZWRpYVBs",
            "YXllck1vZGVscy5QbGF5aW5nTWVkaWFJbmZvQ2hhbmdlZC5NZWRpYVByb3Bl",
            "cnR5IjIKDU1lZGlhUHJvcGVydHkSCQoFU3RhdGUQABIMCghQb3NpdGlvbhAB",
            "EggKBEZpbGUQAio5CgVTdGF0ZRILCgdVbmtub3duEAASCwoHUGxheWluZxAB",
            "EgoKBlBhdXNlZBACEgoKBlN0b3BlZBADQiqqAidMb2NhbE5ldGZsaXguUHJv",
            "dG9idWYuTWVkaWFQbGF5ZXJNb2RlbHNiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::LocalNetflix.Protobuf.MediaPlayerModels.State), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfo), global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfo.Parser, new[]{ "FileName", "Duration", "Eplipsed", "State" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::LocalNetflix.Protobuf.MediaPlayerModels.OpenFile), global::LocalNetflix.Protobuf.MediaPlayerModels.OpenFile.Parser, new[]{ "FileName" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfoChanged), global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfoChanged.Parser, new[]{ "MediaInfo", "OldMediaInfo", "Property" }, null, new[]{ typeof(global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfoChanged.Types.MediaProperty) }, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum State {
    [pbr::OriginalName("Unknown")] Unknown = 0,
    [pbr::OriginalName("Playing")] Playing = 1,
    [pbr::OriginalName("Paused")] Paused = 2,
    [pbr::OriginalName("Stoped")] Stoped = 3,
  }

  #endregion

  #region Messages
  public sealed partial class PlayingMediaInfo : pb::IMessage<PlayingMediaInfo> {
    private static readonly pb::MessageParser<PlayingMediaInfo> _parser = new pb::MessageParser<PlayingMediaInfo>(() => new PlayingMediaInfo());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PlayingMediaInfo> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::LocalNetflix.Protobuf.MediaPlayerModels.MediaPlayerModelsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PlayingMediaInfo() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PlayingMediaInfo(PlayingMediaInfo other) : this() {
      fileName_ = other.fileName_;
      duration_ = other.duration_;
      eplipsed_ = other.eplipsed_;
      state_ = other.state_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PlayingMediaInfo Clone() {
      return new PlayingMediaInfo(this);
    }

    /// <summary>Field number for the "FileName" field.</summary>
    public const int FileNameFieldNumber = 1;
    private string fileName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FileName {
      get { return fileName_; }
      set {
        fileName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Duration" field.</summary>
    public const int DurationFieldNumber = 2;
    private double duration_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Duration {
      get { return duration_; }
      set {
        duration_ = value;
      }
    }

    /// <summary>Field number for the "Eplipsed" field.</summary>
    public const int EplipsedFieldNumber = 3;
    private double eplipsed_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Eplipsed {
      get { return eplipsed_; }
      set {
        eplipsed_ = value;
      }
    }

    /// <summary>Field number for the "State" field.</summary>
    public const int StateFieldNumber = 4;
    private global::LocalNetflix.Protobuf.MediaPlayerModels.State state_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::LocalNetflix.Protobuf.MediaPlayerModels.State State {
      get { return state_; }
      set {
        state_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PlayingMediaInfo);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PlayingMediaInfo other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (FileName != other.FileName) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Duration, other.Duration)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Eplipsed, other.Eplipsed)) return false;
      if (State != other.State) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (FileName.Length != 0) hash ^= FileName.GetHashCode();
      if (Duration != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Duration);
      if (Eplipsed != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Eplipsed);
      if (State != 0) hash ^= State.GetHashCode();
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
      if (FileName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(FileName);
      }
      if (Duration != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Duration);
      }
      if (Eplipsed != 0D) {
        output.WriteRawTag(25);
        output.WriteDouble(Eplipsed);
      }
      if (State != 0) {
        output.WriteRawTag(32);
        output.WriteEnum((int) State);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (FileName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(FileName);
      }
      if (Duration != 0D) {
        size += 1 + 8;
      }
      if (Eplipsed != 0D) {
        size += 1 + 8;
      }
      if (State != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) State);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PlayingMediaInfo other) {
      if (other == null) {
        return;
      }
      if (other.FileName.Length != 0) {
        FileName = other.FileName;
      }
      if (other.Duration != 0D) {
        Duration = other.Duration;
      }
      if (other.Eplipsed != 0D) {
        Eplipsed = other.Eplipsed;
      }
      if (other.State != 0) {
        State = other.State;
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
            FileName = input.ReadString();
            break;
          }
          case 17: {
            Duration = input.ReadDouble();
            break;
          }
          case 25: {
            Eplipsed = input.ReadDouble();
            break;
          }
          case 32: {
            state_ = (global::LocalNetflix.Protobuf.MediaPlayerModels.State) input.ReadEnum();
            break;
          }
        }
      }
    }

  }

  public sealed partial class OpenFile : pb::IMessage<OpenFile> {
    private static readonly pb::MessageParser<OpenFile> _parser = new pb::MessageParser<OpenFile>(() => new OpenFile());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<OpenFile> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::LocalNetflix.Protobuf.MediaPlayerModels.MediaPlayerModelsReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OpenFile() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OpenFile(OpenFile other) : this() {
      fileName_ = other.fileName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OpenFile Clone() {
      return new OpenFile(this);
    }

    /// <summary>Field number for the "FileName" field.</summary>
    public const int FileNameFieldNumber = 1;
    private string fileName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FileName {
      get { return fileName_; }
      set {
        fileName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as OpenFile);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(OpenFile other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (FileName != other.FileName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (FileName.Length != 0) hash ^= FileName.GetHashCode();
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
      if (FileName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(FileName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (FileName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(FileName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(OpenFile other) {
      if (other == null) {
        return;
      }
      if (other.FileName.Length != 0) {
        FileName = other.FileName;
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
            FileName = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class PlayingMediaInfoChanged : pb::IMessage<PlayingMediaInfoChanged> {
    private static readonly pb::MessageParser<PlayingMediaInfoChanged> _parser = new pb::MessageParser<PlayingMediaInfoChanged>(() => new PlayingMediaInfoChanged());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PlayingMediaInfoChanged> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::LocalNetflix.Protobuf.MediaPlayerModels.MediaPlayerModelsReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PlayingMediaInfoChanged() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PlayingMediaInfoChanged(PlayingMediaInfoChanged other) : this() {
      mediaInfo_ = other.mediaInfo_ != null ? other.mediaInfo_.Clone() : null;
      oldMediaInfo_ = other.oldMediaInfo_ != null ? other.oldMediaInfo_.Clone() : null;
      property_ = other.property_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PlayingMediaInfoChanged Clone() {
      return new PlayingMediaInfoChanged(this);
    }

    /// <summary>Field number for the "MediaInfo" field.</summary>
    public const int MediaInfoFieldNumber = 1;
    private global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfo mediaInfo_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfo MediaInfo {
      get { return mediaInfo_; }
      set {
        mediaInfo_ = value;
      }
    }

    /// <summary>Field number for the "OldMediaInfo" field.</summary>
    public const int OldMediaInfoFieldNumber = 2;
    private global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfo oldMediaInfo_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfo OldMediaInfo {
      get { return oldMediaInfo_; }
      set {
        oldMediaInfo_ = value;
      }
    }

    /// <summary>Field number for the "Property" field.</summary>
    public const int PropertyFieldNumber = 3;
    private global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfoChanged.Types.MediaProperty property_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfoChanged.Types.MediaProperty Property {
      get { return property_; }
      set {
        property_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PlayingMediaInfoChanged);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PlayingMediaInfoChanged other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(MediaInfo, other.MediaInfo)) return false;
      if (!object.Equals(OldMediaInfo, other.OldMediaInfo)) return false;
      if (Property != other.Property) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (mediaInfo_ != null) hash ^= MediaInfo.GetHashCode();
      if (oldMediaInfo_ != null) hash ^= OldMediaInfo.GetHashCode();
      if (Property != 0) hash ^= Property.GetHashCode();
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
      if (mediaInfo_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(MediaInfo);
      }
      if (oldMediaInfo_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(OldMediaInfo);
      }
      if (Property != 0) {
        output.WriteRawTag(24);
        output.WriteEnum((int) Property);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (mediaInfo_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(MediaInfo);
      }
      if (oldMediaInfo_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(OldMediaInfo);
      }
      if (Property != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Property);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PlayingMediaInfoChanged other) {
      if (other == null) {
        return;
      }
      if (other.mediaInfo_ != null) {
        if (mediaInfo_ == null) {
          mediaInfo_ = new global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfo();
        }
        MediaInfo.MergeFrom(other.MediaInfo);
      }
      if (other.oldMediaInfo_ != null) {
        if (oldMediaInfo_ == null) {
          oldMediaInfo_ = new global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfo();
        }
        OldMediaInfo.MergeFrom(other.OldMediaInfo);
      }
      if (other.Property != 0) {
        Property = other.Property;
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
            if (mediaInfo_ == null) {
              mediaInfo_ = new global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfo();
            }
            input.ReadMessage(mediaInfo_);
            break;
          }
          case 18: {
            if (oldMediaInfo_ == null) {
              oldMediaInfo_ = new global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfo();
            }
            input.ReadMessage(oldMediaInfo_);
            break;
          }
          case 24: {
            property_ = (global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfoChanged.Types.MediaProperty) input.ReadEnum();
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the PlayingMediaInfoChanged message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public enum MediaProperty {
        [pbr::OriginalName("State")] State = 0,
        [pbr::OriginalName("Position")] Position = 1,
        [pbr::OriginalName("File")] File = 2,
      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code