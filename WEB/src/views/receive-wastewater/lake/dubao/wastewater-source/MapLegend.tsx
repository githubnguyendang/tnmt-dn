import { Checkbox, FormControl, FormControlLabel, FormGroup } from "@mui/material";
import { useEffect, useState } from "react";
import { getData } from "src/api/axios";

interface MonitoringData {
  year: number;
  // Add any other fields you expect in filterOptions
}

const MapLegendNuocNhan = ({ onChange }: { onChange: (selectedOption: number | null) => void }) => {
  const [selectedOption, setSelectedOption] = useState<number | null>(null);
  const [years, setYears] = useState<number[]>([]);

  useEffect(() => {
    async function getDataWasteWater() {
      try {
        const data: MonitoringData[] = await getData('ThongSoDiemQuanTrac/list');
        
        // Extract unique years
        const uniqueYears = Array.from(new Set(data.map(item => item.year)));
        
        setYears(uniqueYears);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    }

    getDataWasteWater();
  }, []);

  const handleOptionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const value = parseInt(event.target.value, 10);
    const isChecked = event.target.checked;

    if (isChecked) {
      setSelectedOption(value);
      onChange(value); // Call the parent function with the selected year
    } else {
      setSelectedOption(null);
      onChange(null); // Call the parent function with no selection
    }
  };

  return (
    <FormControl component="fieldset">
      <FormGroup>
        {years.map((year) => (
          <FormControlLabel
            key={year}
            control={
              <Checkbox
                checked={selectedOption === year}
                onChange={handleOptionChange}
                value={year.toString()}
              />
            }
            label={`Năm ${year}`}
          />
        ))}
      </FormGroup>
    </FormControl>
  );
};

export default MapLegendNuocNhan;
