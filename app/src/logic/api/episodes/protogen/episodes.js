/*eslint-disable block-scoped-var, id-length, no-control-regex, no-magic-numbers, no-prototype-builtins, no-redeclare, no-shadow, no-var, sort-vars*/
import * as $protobuf from "protobufjs/minimal";

// Common aliases
const $util = $protobuf.util;

// Exported root namespace
const $root = $protobuf.roots["default"] || ($protobuf.roots["default"] = {});

export const Episode = ($root.Episode = (() => {
  /**
   * Properties of an Episode.
   * @exports IEpisode
   * @interface IEpisode
   * @property {number|null} [seriesId] Episode seriesId
   * @property {number|null} [episodeFileId] Episode episodeFileId
   * @property {number|null} [seasonNumber] Episode seasonNumber
   * @property {number|null} [episideNumber] Episode episideNumber
   * @property {string|null} [title] Episode title
   * @property {string|null} [overview] Episode overview
   */

  /**
   * Constructs a new Episode.
   * @exports Episode
   * @classdesc Represents an Episode.
   * @implements IEpisode
   * @constructor
   * @param {IEpisode=} [properties] Properties to set
   */
  function Episode(properties) {
    if (properties)
      for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
        if (properties[keys[i]] != null) this[keys[i]] = properties[keys[i]];
  }

  /**
   * Episode seriesId.
   * @member {number} seriesId
   * @memberof Episode
   * @instance
   */
  Episode.prototype.seriesId = 0;

  /**
   * Episode episodeFileId.
   * @member {number} episodeFileId
   * @memberof Episode
   * @instance
   */
  Episode.prototype.episodeFileId = 0;

  /**
   * Episode seasonNumber.
   * @member {number} seasonNumber
   * @memberof Episode
   * @instance
   */
  Episode.prototype.seasonNumber = 0;

  /**
   * Episode episideNumber.
   * @member {number} episideNumber
   * @memberof Episode
   * @instance
   */
  Episode.prototype.episideNumber = 0;

  /**
   * Episode title.
   * @member {string} title
   * @memberof Episode
   * @instance
   */
  Episode.prototype.title = "";

  /**
   * Episode overview.
   * @member {string} overview
   * @memberof Episode
   * @instance
   */
  Episode.prototype.overview = "";

  return Episode;
})());

export { $root as default };
