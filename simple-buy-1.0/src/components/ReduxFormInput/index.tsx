
import TextField from '@material-ui/core/TextField'

import './styles.css'

export const ReduxFormInput:React.FC = (field: any) => {
    return(
        <TextField
          {...field.input} 
          required
          error = {(!field.mensagem ? false : true)}
          fullWidth
          id={field.id}
          name={field.name}
          label={field.label}
          placeholder={field.placeholder}
          variant="outlined"
          helperText={field.mensagem}
          className="text-input"          
        />
    )
}
