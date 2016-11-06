package be.pxl.vegisens.domain;

import java.io.Serializable;
import java.time.LocalDateTime;

import javax.persistence.*;


@Entity
@Table(name="humidity_registered_values")
public class HumidityRegisteredValues implements Serializable 
{
    /**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="HUM_REG_ID")
    private int humidityRegisteredId;
    
    @ManyToOne(cascade = CascadeType.MERGE) //(fetch = FetchType.EAGER, cascade = CascadeType.MERGE)
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
