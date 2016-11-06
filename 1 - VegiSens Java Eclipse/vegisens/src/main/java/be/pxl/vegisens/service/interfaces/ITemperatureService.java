package be.pxl.vegisens.service.interfaces;

import be.pxl.vegisens.domain.Temperature;

public interface ITemperatureService
{
	Temperature addTemperature(Temperature temperatureToAdd);
	Temperature updateTemperature(Temperature temperatureToUpdate);
}
