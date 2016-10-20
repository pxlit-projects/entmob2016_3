package be.pxl.vegisens.application;

import java.io.Serializable;
import javax.persistence.*;


@Entity
@Table(name="humidity")
public class Humidity implements Serializable 
{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="HUMIDITY_ID")
    private int id;

    @Column(name="MIN_IDEAL_HUMIDITY")
    private double minHumidity;

    @Column(name="MAX_IDEAL_HUMIDITY")
    private double maxHumidity;

	public int getId() {
		return id;
	}

	public double getMinHumidity() {
		return minHumidity;
	}

	public double getMaxHumidity() {
		return maxHumidity;
	}
}
