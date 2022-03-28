import React from 'react';
import PostItem from './PostItem';
import  PropTypes from 'prop-types';

export class Posts extends React.Component {
	render() {
		
		return this.props.posts.map((post) => (
				<PostItem key={post.postId} post ={post} delPost={this.props.delPost} likes={this.props.likes} hearts={this.props.hearts} updatePost={this.props.updatePost}/>
					))
			}
	}

Posts.propTypes = {
  posts: PropTypes.array.isRequired,
}
export default Posts;