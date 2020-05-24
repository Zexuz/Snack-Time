const rewireGqlTag = require('react-app-rewire-graphql-tag');

module.exports = function override(config, env) {
    const conf = rewireGqlTag(config,env);
    return conf;
}
