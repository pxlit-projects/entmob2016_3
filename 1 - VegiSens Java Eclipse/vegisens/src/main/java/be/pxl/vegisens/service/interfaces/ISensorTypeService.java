package be.pxl.vegisens.service.interfaces;

import java.util.List;

import be.pxl.vegisens.domain.SensorType;

public interface ISensorTypeService {

	List<SensorType> getAllSensorTypes();
	SensorType getSensorTypeById(int sensorTypeId);
}
