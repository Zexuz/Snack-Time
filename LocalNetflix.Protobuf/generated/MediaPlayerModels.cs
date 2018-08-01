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
            "dGlvbhgCIAEoBRIQCghFcGxpcHNlZBgDIAEoBRInCgVTdGF0ZRgEIAEoDjIY",
            "Lk1lZGlhUGxheWVyTW9kZWxzLlN0YXRlKjkKBVN0YXRlEgsKB1Vua25vd24Q",
            "ABILCgdQbGF5aW5nEAESCgoGUGF1c2VkEAISCgoGU3RvcGVkEANCKqoCJ0xv",
            "Y2FsTmV0ZmxpeC5Qcm90b2J1Zi5NZWRpYVBsYXllck1vZGVsc2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::LocalNetflix.Protobuf.MediaPlayerModels.State), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfo), global::LocalNetflix.Protobuf.MediaPlayerModels.PlayingMediaInfo.Parser, new[]{ "FileName", "Duration", "Eplipsed", "State" }, null, null, null)
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
    private int duration_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Duration {
      get { return duration_; }
      set {
        duration_ = value;
      }
    }

    /// <summary>Field number for the "Eplipsed" field.</summary>
    public const int EplipsedFieldNumber = 3;
    private int eplipsed_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Eplipsed {
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
      if (Duration != other.Duration) return false;
      if (Eplipsed != other.Eplipsed) return false;
      if (State != other.State) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (FileName.Length != 0) hash ^= FileName.GetHashCode();
      if (Duration != 0) hash ^= Duration.GetHashCode();
      if (Eplipsed != 0) hash ^= Eplipsed.GetHashCode();
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
      if (Duration != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Duration);
      }
      if (Eplipsed != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Eplipsed);
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
      if (Duration != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Duration);
      }
      if (Eplipsed != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Eplipsed);
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
      if (other.Duration != 0) {
        Duration = other.Duration;
      }
      if (other.Eplipsed != 0) {
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
          case 16: {
            Duration = input.ReadInt32();
            break;
          }
          case 24: {
            Eplipsed = input.ReadInt32();
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

  #endregion

}

#endregion Designer generated code
