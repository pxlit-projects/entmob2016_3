package be.pxl.vegisens.application;

import java.util.List;

public interface ISensorTypeService {

	List<SensorType> getAllSensorTypes();
	SensorType getSensorTypeById(int sensorTypeId);
}
