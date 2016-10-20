package be.pxl.vegisens.application;

import java.io.Serializable;
import java.time.LocalDateTime;

import javax.persistence.*;


@Entity
@Table(name="humidity_registered_values")
public class HumidityRegisteredValues implements Serializable 
{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="HUM_REG_ID")
    private int humidityRegisteredId;
    
    @ManyToOne
    @JoinColumn(name="HUM_FK", referencedColumnName="SENSORTYPE_ID")
    private SensorType sensortype;
    
	@Column(name="HUM_DATE")
    private LocalDateTime date;

    @Column(name="HUM_VALUE")
    private double value;

	public int getHumidityRegisteredIdId() {
		return humidityRegisteredId;
	}

	public LocalDateTime getDate() {
		return date;
	}

	public double getValue() {
		return value;
	}

}
