using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace SnackTime.Core.Media.Episodes.proto.gen
{
    public sealed partial class Episode : IMessage<Episode> {
        private static readonly MessageParser<Episode> _parser = new MessageParser<Episode>(() => new Episode());
        private                 UnknownFieldSet        _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageParser<Episode> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static MessageDescriptor Descriptor {
            get { return global::SnackTime.Core.Media.Episodes.proto.gen.TypesReflection.Descriptor.MessageTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        MessageDescriptor IMessage.Descriptor {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Episode() {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Episode(Episode other) : this() {
            seriesId_ = other.seriesId_;
            episodeFileId_ = other.episodeFileId_;
            seasonNumber_ = other.seasonNumber_;
            episideNumber_ = other.episideNumber_;
            title_ = other.title_;
            overview_ = other.overview_;
            _unknownFields = UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Episode Clone() {
            return new Episode(this);
        }

        /// <summary>Field number for the "seriesId" field.</summary>
        public const int SeriesIdFieldNumber = 1;
        private int seriesId_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int SeriesId {
            get { return seriesId_; }
            set {
                seriesId_ = value;
            }
        }

        /// <summary>Field number for the "episodeFileId" field.</summary>
        public const int EpisodeFileIdFieldNumber = 2;
        private int episodeFileId_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int EpisodeFileId {
            get { return episodeFileId_; }
            set {
                episodeFileId_ = value;
            }
        }

        /// <summary>Field number for the "seasonNumber" field.</summary>
        public const int SeasonNumberFieldNumber = 3;
        private int seasonNumber_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int SeasonNumber {
            get { return seasonNumber_; }
            set {
                seasonNumber_ = value;
            }
        }

        /// <summary>Field number for the "episideNumber" field.</summary>
        public const int EpisideNumberFieldNumber = 4;
        private int episideNumber_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int EpisideNumber {
            get { return episideNumber_; }
            set {
                episideNumber_ = value;
            }
        }

        /// <summary>Field number for the "title" field.</summary>
        public const int TitleFieldNumber = 5;
        private string title_ = "";
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Title {
            get { return title_; }
            set {
                title_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "overview" field.</summary>
        public const int OverviewFieldNumber = 6;
        private string overview_ = "";
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Overview {
            get { return overview_; }
            set {
                overview_ = ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
            return Equals(other as Episode);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(Episode other) {
            if (ReferenceEquals(other, null)) {
                return false;
            }
            if (ReferenceEquals(other, this)) {
                return true;
            }
            if (SeriesId      != other.SeriesId) return false;
            if (EpisodeFileId != other.EpisodeFileId) return false;
            if (SeasonNumber  != other.SeasonNumber) return false;
            if (EpisideNumber != other.EpisideNumber) return false;
            if (Title         != other.Title) return false;
            if (Overview      != other.Overview) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
            int hash = 1;
            if (SeriesId        != 0) hash ^= SeriesId.GetHashCode();
            if (EpisodeFileId   != 0) hash ^= EpisodeFileId.GetHashCode();
            if (SeasonNumber    != 0) hash ^= SeasonNumber.GetHashCode();
            if (EpisideNumber   != 0) hash ^= EpisideNumber.GetHashCode();
            if (Title.Length    != 0) hash ^= Title.GetHashCode();
            if (Overview.Length != 0) hash ^= Overview.GetHashCode();
            if (_unknownFields != null) {
                hash ^= _unknownFields.GetHashCode();
            }
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
            return JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(CodedOutputStream output) {
            if (SeriesId != 0) {
                output.WriteRawTag(8);
                output.WriteInt32(SeriesId);
            }
            if (EpisodeFileId != 0) {
                output.WriteRawTag(16);
                output.WriteInt32(EpisodeFileId);
            }
            if (SeasonNumber != 0) {
                output.WriteRawTag(24);
                output.WriteInt32(SeasonNumber);
            }
            if (EpisideNumber != 0) {
                output.WriteRawTag(32);
                output.WriteInt32(EpisideNumber);
            }
            if (Title.Length != 0) {
                output.WriteRawTag(42);
                output.WriteString(Title);
            }
            if (Overview.Length != 0) {
                output.WriteRawTag(50);
                output.WriteString(Overview);
            }
            if (_unknownFields != null) {
                _unknownFields.WriteTo(output);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
            int size = 0;
            if (SeriesId != 0) {
                size += 1 + CodedOutputStream.ComputeInt32Size(SeriesId);
            }
            if (EpisodeFileId != 0) {
                size += 1 + CodedOutputStream.ComputeInt32Size(EpisodeFileId);
            }
            if (SeasonNumber != 0) {
                size += 1 + CodedOutputStream.ComputeInt32Size(SeasonNumber);
            }
            if (EpisideNumber != 0) {
                size += 1 + CodedOutputStream.ComputeInt32Size(EpisideNumber);
            }
            if (Title.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(Title);
            }
            if (Overview.Length != 0) {
                size += 1 + CodedOutputStream.ComputeStringSize(Overview);
            }
            if (_unknownFields != null) {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(Episode other) {
            if (other == null) {
                return;
            }
            if (other.SeriesId != 0) {
                SeriesId = other.SeriesId;
            }
            if (other.EpisodeFileId != 0) {
                EpisodeFileId = other.EpisodeFileId;
            }
            if (other.SeasonNumber != 0) {
                SeasonNumber = other.SeasonNumber;
            }
            if (other.EpisideNumber != 0) {
                EpisideNumber = other.EpisideNumber;
            }
            if (other.Title.Length != 0) {
                Title = other.Title;
            }
            if (other.Overview.Length != 0) {
                Overview = other.Overview;
            }
            _unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(CodedInputStream input) {
            uint tag;
            while ((tag = input.ReadTag()) != 0) {
                switch(tag) {
                    default:
                        _unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                        break;
                    case 8: {
                        SeriesId = input.ReadInt32();
                        break;
                    }
                    case 16: {
                        EpisodeFileId = input.ReadInt32();
                        break;
                    }
                    case 24: {
                        SeasonNumber = input.ReadInt32();
                        break;
                    }
                    case 32: {
                        EpisideNumber = input.ReadInt32();
                        break;
                    }
                    case 42: {
                        Title = input.ReadString();
                        break;
                    }
                    case 50: {
                        Overview = input.ReadString();
                        break;
                    }
                }
            }
        }

    }
}