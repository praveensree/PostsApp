import React from 'react';
import PropTypes from 'prop-types';
import {Card} from 'reactstrap';
import axios from 'axios';
import Comments from './Comments' ;
import EditPost from './EditPost';
import { BrowserRouter as Router , Route, Link, IndexRoute, Switch} from 'react-router-dom';
import { Button, Modal, ModalHeader, ModalBody } from 'reactstrap';

export class PostItem extends React.Component {
	
	state ={
		postmodal:false,
		modal: false,
		toggleLike: false,
		toggleHeart: false
	};
	toggle = () =>{
		this.setState({modal : !this.state.modal})
	}
	posttoggle = () =>{
		this.setState({postmodal : !this.state.postmodal})
	}
  setLikeButton=(postId)=>{
		
			this.setState({toggleLike:!this.state.toggleLike})
			this.props.likes(this.state.toggleLike,postId)
	}
	setHeartButton=(postId)=>{
		
			this.setState({toggleHeart:!this.state.toggleHeart})
			this.props.hearts(this.state.toggleHeart,postId)
	}

	

	
	render() {
		const {postId,postName,postDescription,likes,hearts} = this.props.post;
		return (
			<Router>
		  <div class="card border-primary mb-3" style={{width: '40rem' , margin: 'auto'}}>
			  <div class="card-header">
			  </div>
			    <div class="card-body">
			     <h4 class="card-title">{postName}</h4>
				 <span>
			    <p class="card-text">{postDescription}</p>	
				</span>
				<span>
				<a href="#" onClick={this.posttoggle}>edit</a>
				</span>
				<span>
                <Button className="button-7" onClick={this.setLikeButton.bind(this,postId)} >{!this.state.toggleLike ? "👍" : "👎"}</Button>Likes|: {likes}
                </span>
                <span>
                <Button className="button-7" onClick={this.setHeartButton.bind(this,postId)} >{!this.state.toggleHeart ? "❤️" : "💔"}</Button>Hearts|: {hearts}
                </span>
			    <a href="#" onClick={this.toggle}>Comments</a>
					<Modal isOpen={this.state.modal} toggle={this.toggle} >
					<ModalHeader toggle={this.toggle}>Comments</ModalHeader>
					<ModalBody>
					<Comments postId={this.props.post.postId} editcomment={this.editComment}/>
					</ModalBody>
						</Modal>
			    
			    		  
		  </div>
		 
					<Modal isOpen={this.state.postmodal} posttoggle={this.posttoggle} >
					<ModalHeader toggle={this.posttoggle}>Comments</ModalHeader>
					<ModalBody>
					<EditPost postId={this.props.post.postId} postName={this.props.post.postName} postDescription={this.props.post.postDescription} updatePost={this.props.updatePost}/>
					</ModalBody>
						</Modal>
		  </div>	
		  </Router>		
		);
	}
}


export default PostItem;