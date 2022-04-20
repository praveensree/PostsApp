import React from 'react';
import { Button, Modal, ModalHeader, ModalBody, Form, FormGroup } from 'reactstrap';
import {Card} from 'reactstrap';
	

class AddPost extends React.Component {
	state = {
		postName: '',
		postDescription: ''		
	}

	
	onSubmit = (e) => {
		e.preventDefault();
	this.props.addpost(this.state.postName, this.state.postDescription);
	this.setState({ postName: '', postDescription: ''});
}

onChange = (e) => this.setState({ [e.target.name]: e.target.value });

	render(){
		return (
			
			<div className="card border-primary mb-3" style={{width: '40rem' , margin: 'auto'}}>
				<Card>
					<Form onSubmit={this.onSubmit} >
					<FormGroup>
					<input type="text" name="postName"  placeholder="Title ..." value={this.state.postName} onChange={this.onChange} autoFocus/>
					</FormGroup>

					<FormGroup>
						<textarea  name="postDescription" rows="5" cols="60" value={this.state.postDescription} onChange={this.onChange} />
					</FormGroup>

					<FormGroup>
						<button type="submit" className="btn btn-primary" onClick={this.toggle}>Post</button>
					</FormGroup>

					</Form>
					</Card>
					
	</div>
	
		)
	}
}

export default AddPost

 