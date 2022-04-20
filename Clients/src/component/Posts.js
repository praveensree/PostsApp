import React from 'react';
import PostItem from './PostItem';

export class Posts extends React.Component {
	render() {
		
		return this.props.posts.map((post) => (
				<PostItem key={post.postId} post ={post} delPost={this.props.delPost} likes={this.props.likes} hearts={this.props.hearts} updatePost={this.props.updatePost}/>
					))
			}
	}


export default Posts;