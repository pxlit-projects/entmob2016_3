package be.pxl.vegisens.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.vegisens.domain.SensorType;
import be.pxl.vegisens.repository.SensorTypeRepository;
import be.pxl.vegisens.service.interfaces.ISensorTypeService;

@Service
@Transactional
public class SensorTypeServiceImpl implements ISensorTypeService
{
	@Autowired
	private SensorTypeRepository sensorTypeRepository;

	public List<SensorType> getAllSensorTypes() 
	{
		return (List<SensorType>) sensorTypeRepository.findAll();
	}

	@Override
	public SensorType getSensorTypeById(int sensorTypeId)
	{
		return sensorTypeRepository.findOne(sensorTypeId);
	}
	
}


