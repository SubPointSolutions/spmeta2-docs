#!/usr/bin/ruby 

require_relative 'lib/build_logger.rb'
require_relative 'lib/build_helpers.rb'

$logger = Logger.new(STDOUT)
configure_logger(logger: $logger) 

current_folder = File.expand_path(File.dirname(__FILE__))
$logger.debug "Running in folder: #{current_folder}"

$logger.debug "Parsing command line params"

options = {
    :config                    => "dev",
    :git_cache_path            => "./.docs-source"
}

parser = OptionParser.new do|opts|

    opts.banner = ""
   
    opts.on('-c', '--config=VALUE', 'Config to use') do |value|
		options[:config] = value;
	end

    opts.on('-g', '--git-cache-path=VALUE', 'Where to checkout doco repos') do |value|
		options[:git_cache_path] = value;
    end

    opts.on('-p', '--parallel=VALUE', 'Enable parallel build') do |name|
		options[:enable_parallel_build] = true;
    end
    
end

parser.parse!

$logger.debug "Running with options:"
$logger.debug options.to_yaml

$logger.debug("Reading docs metadata configuration")
git_metadata = load_git_metadata(config_name: options[:config])

$logger.info("Fetching repos...")

fetch_repos(git_metadata: git_metadata["repos"], options: options)
$logger.info("Completed!")

exit(0)