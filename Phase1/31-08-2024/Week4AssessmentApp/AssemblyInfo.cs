<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<configSections>
		<section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
	</configSections>

	<log4net>
		<!-- File Appender -->
		<appender name="FileAppender" type="log4net.Appender.RollingFileAppender">
			<file value="week4assessment_app_log.log" />
			<appendToFile value="true" />
			<rollingStyle value="Size" />
			<maxSizeRollBackups value="5" />
			<maximumFileSize value="10MB" />
			<staticLogFileName value="true" />
			<layout type="log4net.Layout.PatternLayout">
				<conversionPattern value="%date [%thread] %-5level %logger - %message%newline" />
			</layout>
		</appender>

		<!-- Console Appender -->
		<appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender">
			<layout type="log4net.Layout.PatternLayout">
				<conversionPattern value="%date [%thread] %-5level %logger - %message%newline" />
			</layout>
		</appender>

		<!-- Root logger -->
		<root>
			<level value="ALL" />
			<appender-ref ref="FileAppender" />
			<appender-ref ref="ConsoleAppender" />
		</root>
	</log4net>
	<startup>
		<supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
	</startup>
</configuration>