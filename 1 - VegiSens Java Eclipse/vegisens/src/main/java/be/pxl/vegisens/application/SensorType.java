package be.pxl.vegisens.application;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.*;


@Entity
@Table(name="sensortype")
public class SensorType implements Serializable 
{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="SENSORTYPE_ID")
    private int sensortypeId;
   
    @OneToMany(mappedBy="sensortype")
    private List<TemperatureRegisteredValues> temperatureValues = new ArrayList<TemperatureRegisteredValues>();
    
    @OneToMany(mappedBy="sensortype")
    private List<HumidityRegisteredValues> humidityValues = new ArrayList<HumidityRegisteredValues>();
    
	@Column(name="SENSOR_NAME")
    private String sensorName;

    @Column(name="SENSOR_UNIT")
    private String sensorUnit;

	public int getSensortypeId() {
		return sensortypeId;
	}

	public List<TemperatureRegisteredValues> getTemperatureValues() {
		return temperatureValues;
	}

	public List<HumidityRegisteredValues> getHumidityValues() {
		return humidityValues;
	}

	public String getSensorName() {
		return sensorName;
	}

	public String getSensorUnit() {
		return sensorUnit;
	}

}