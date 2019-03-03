/*eslint-disable block-scoped-var, id-length, no-control-regex, no-magic-numbers, no-prototype-builtins, no-redeclare, no-shadow, no-var, sort-vars*/
import * as $protobuf from "protobufjs/minimal";

// Common aliases
const $util = $protobuf.util;

// Exported root namespace
const $root = $protobuf.roots["default"] || ($protobuf.roots["default"] = {});

export const Series = $root.Series = (() => {

    /**
     * Properties of a Series.
     * @exports ISeries
     * @interface ISeries
     * @property {number|null} [id] Series id
     * @property {string|null} [title] Series title
     * @property {IImagesUrl|null} [imagesUrl] Series imagesUrl
     */

    /**
     * Constructs a new Series.
     * @exports Series
     * @classdesc Represents a Series.
     * @implements ISeries
     * @constructor
     * @param {ISeries=} [properties] Properties to set
     */
    function Series(properties) {
        if (properties)
            for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                if (properties[keys[i]] != null)
                    this[keys[i]] = properties[keys[i]];
    }

    /**
     * Series id.
     * @member {number} id
     * @memberof Series
     * @instance
     */
    Series.prototype.id = 0;

    /**
     * Series title.
     * @member {string} title
     * @memberof Series
     * @instance
     */
    Series.prototype.title = "";

    /**
     * Series imagesUrl.
     * @member {IImagesUrl|null|undefined} imagesUrl
     * @memberof Series
     * @instance
     */
    Series.prototype.imagesUrl = null;

    return Series;
})();

export const ImagesUrl = $root.ImagesUrl = (() => {

    /**
     * Properties of an ImagesUrl.
     * @exports IImagesUrl
     * @interface IImagesUrl
     * @property {string|null} [banner] ImagesUrl banner
     * @property {string|null} [fanart] ImagesUrl fanart
     * @property {string|null} [poster] ImagesUrl poster
     */

    /**
     * Constructs a new ImagesUrl.
     * @exports ImagesUrl
     * @classdesc Represents an ImagesUrl.
     * @implements IImagesUrl
     * @constructor
     * @param {IImagesUrl=} [properties] Properties to set
     */
    function ImagesUrl(properties) {
        if (properties)
            for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                if (properties[keys[i]] != null)
                    this[keys[i]] = properties[keys[i]];
    }

    /**
     * ImagesUrl banner.
     * @member {string} banner
     * @memberof ImagesUrl
     * @instance
     */
    ImagesUrl.prototype.banner = "";

    /**
     * ImagesUrl fanart.
     * @member {string} fanart
     * @memberof ImagesUrl
     * @instance
     */
    ImagesUrl.prototype.fanart = "";

    /**
     * ImagesUrl poster.
     * @member {string} poster
     * @memberof ImagesUrl
     * @instance
     */
    ImagesUrl.prototype.poster = "";

    return ImagesUrl;
})();

export { $root as default };
