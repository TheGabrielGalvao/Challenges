
import TextField from '@material-ui/core/TextField'
import { useState } from 'react';


export const ReduxFormSelect:React.FC = (field: any) => {
    
    const [value, setValue] = useState('')

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setValue(event.target.value);
      };
    return(
        <TextField
          {...field.input} 
          className="select"
          id={field.id}
          name={field.name}
          select
          error ={(!field.mensagem ? false : true)}
          label={field.label}
          placeholder={field.label}
          onChange={handleChange}
          value={value}
          SelectProps={{
            native: true,
          }}
          helperText={field.mensagem}
          variant="outlined"
        >
          {field.lista.map((option:any) => (
            <option key={option.value} value={option.value}>
              {option.label}
            </option>
          ))}
        </TextField>
    )
}

