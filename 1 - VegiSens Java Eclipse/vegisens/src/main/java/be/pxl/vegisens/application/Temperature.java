package be.pxl.vegisens.application;

import java.io.Serializable;
import javax.persistence.*;


@Entity
@Table(name="temperature")
public class Temperature implements Serializable 
{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="TEMPERATURE_ID")
    private int temperatureId;

    @Column(name="MIN_IDEAL_TEMPERATURE")
    private double minTemperature;

    @Column(name="MAX_IDEAL_TEMPERATURE")
    private double maxTemperature;

	public int getId() {
		return temperatureId;
	}

	public double getMinTemperature() {
		return minTemperature;
	}

	public double getMaxTemperature() {
		return maxTemperature;
	}
}
