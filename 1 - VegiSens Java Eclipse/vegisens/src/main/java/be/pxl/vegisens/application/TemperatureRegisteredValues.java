package be.pxl.vegisens.application;

import java.io.Serializable;
import java.time.LocalDateTime;

import javax.persistence.*;


@Entity
@Table(name="temperature_registered_values")
public class TemperatureRegisteredValues implements Serializable 
{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="TEMP_REG_ID")
    private int temperatureRegisteredId;
    
	@ManyToOne
    @JoinColumn(name="TEMP_FK", referencedColumnName="SENSORTYPE_ID")
    private SensorType sensortype;
    
	@Column(name="TEMP_DATE")
    private LocalDateTime date;

    @Column(name="TEMP_VALUE")
    private double value;

    public int getTemperatureRegisteredId() {
		return temperatureRegisteredId;
	}

	public LocalDateTime getDate() {
		return date;
	}

	public double getValue() {
		return value;
	}
}
