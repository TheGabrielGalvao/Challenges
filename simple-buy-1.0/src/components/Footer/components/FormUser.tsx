import { Field, InjectedFormProps, reduxForm } from 'redux-form';
import { useHistory } from 'react-router-dom';
import { ReduxFormInput, ReduxFormSelect } from '../..';
import { connect } from 'react-redux';
import { Button } from '../../Button';
import {finalizar} from '../../../store/ducks/Cart/actions'
import { ApplicationState } from '../../../store';
import { IUsuario } from '../../../store/interfaces/IUsuario';
import { bindActionCreators, Dispatch } from 'redux';
import { ICart } from '../../../store/ducks/Cart/types';


const generos = [
    {
      value: 'none',
      label: '',
    },
    {
      value: 'Masculino',
      label: 'Masculino',
    },
    {
      value: 'Feminino',
      label: 'Feminino',
    },
    {
      value: 'Outros',
      label: 'Outros',
    },
  ];
  



interface StateProps{
  cart: ICart
}

interface DispatchProps {
  finalizar(usuario: IUsuario): void
}

type Props = StateProps & DispatchProps

const FormUser:React.FC<Props & InjectedFormProps<{}, Props>> = ({handleSubmit, finalizar, cart}) => {
  const history = useHistory()

  const submit = (data:any) =>{
    if(data != null && data !== {} && data !== ""){
      finalizar(data)
    }
    if(Object.entries(cart.validacao).length === 0){
      history.push("/checkout")
    }
    
  }

  

  return (
    <>
    <form className="" onSubmit={handleSubmit((fields:any) => submit(fields))} noValidate autoComplete="off">

     <div className="fields" style={{display:'flex', flexWrap:'wrap'}}>
        <Field
          required
          fullWidth
          id="name"
          name="name"
          label="Nome"
          placeholder="Nome"
          variant="outlined"
          component={ReduxFormInput}
          mensagem={cart.validacao?.name}
        />
        <Field
          required
          fullWidth
          id="email"
          name="email"
          label="E-mail"
          placeholder="E-mail"
          variant="outlined"
          component={ReduxFormInput}
          mensagem={cart.validacao?.email}
        />
        <Field
          id="genero"
          name="genero"
          select
          label="Sexo/Gênero"
          lista= {generos}
          component={ReduxFormSelect}
          mensagem={cart.validacao?.genero}
        />
     </div>
        <div>
          <h2>Total:{Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL' }).format(cart.Total)}</h2>
          <Button type="submit" className="btn btn-secondary btn-buy">Finalizar Compra</Button>
        </div>    
    </form>
    
    </>
  );
}

const form = reduxForm<{}, Props>({
  form: 'user',
})(FormUser)

const mapStateToProps = (state: ApplicationState)=>({
  cart: state.cart
})

const mapDispatchToProps = (dispatch: Dispatch) => bindActionCreators({finalizar}, dispatch)

export default connect(mapStateToProps, mapDispatchToProps)(form);
