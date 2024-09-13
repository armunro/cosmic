using System.Text.Json;
using Serilog;
using YamlDotNet.Serialization;

namespace Cosmic.Aspects.Configuration;

public class CosmicConfig<TRootConfig> where TRootConfig : new()
{
    private readonly string _configPath;
    private readonly ILogger _logger;
    public TRootConfig Active { get; set; }

    public CosmicConfig(string configPath, ILogger logger)
    {
        _configPath = configPath;
        _logger = logger;
    }
    
    public void Save()
    {
         string yaml = new SerializerBuilder().Build().Serialize(Active);
         File.WriteAllText(_configPath, yaml);
    }
    public void Load()
    {
        _logger.Debug("Config Load: {ConfigPath}", _configPath);
        if (!File.Exists(_configPath))
        {
            _logger.Warning("Config Missing {ConfigPath}. Initializing...Saving...", _configPath);
            Active = new TRootConfig();
            Save();
        }
        
        string yaml = File.ReadAllText(_configPath);
        Active = new DeserializerBuilder().Build().Deserialize<TRootConfig>(yaml);
    }
    
}